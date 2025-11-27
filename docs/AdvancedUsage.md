# Advanced Usage

**SimpleBuffs** was built to be fully self-contained and work regardless of your game's architecture or setup. However, if you are in-need of features not supported by the plugin and you are comfortable with C++, you can still use the various components of SimpleBuffs without using the full system. This guide will walk through an advanced usage of SimpleBuffs.

## **SimpleBuffs** Design

**SimpleBuffs** is setup with 3 layers.

* Subsystems (`USimpleBuffsSubsystem` & `USimpleBuffsTurnBasedSubsystem`)
* Coordinator (`USimpleBuffsCoordinator`)
* Buff (`USimpleBuff` & `FSimpleBuffDefinition`)

These three layers work to create the full functionality **SimpleBuffs** offers. Each layer is built to be standalone and work without the other. So in the event you need something different than what the plugin offers, you can:

* Use the Coordinator without the Subsystems
* Use the Buff without the Subsystems or the Coordinator
* Subclass `USimpleBuffsCoordinator` or `USimpleBuff` to augment its functionality.

## How to Subclass the Coordinator or Buff

Every public and protected function in the `USimpleBuffsCoordinator` and `USimpleBuff` is marked as `virtual` and can be overriden.

### Subclassing `USimpleBuffsCoordinator`

To use your custom `USimpleBuffsCoordinator` with the Subsystems, you will also need to subclass and override the function on `USimpleBuffsCoordinatorFactory`:

```c++
// USimpleBuffsCoordinatorFactory

virtual USimpleBuffsCoordinator* CreateCoordinator(AActor* TargetActor, USimpleBuffsSubsystemDefinition* SubsystemDefinition);
```

This is used to create Coordinators within the Subsystems and the default property can be overriden by setting:

```c++
// USimpleBuffsSubsystem & USimpleBuffsTurnBasedSubsystem

USimpleBuffsCoordinatorFactory* CoordinatorFactory;
```

Inside this function, you can setup your custom Coordinator and you will need to ensure these two functions are called with the two parameters:

```c++
// USimpleBuffsCoordinatorFactory

CustomCoordinator->SetTarget(TargetActor);
CustomCoordinator->RegisterSubsystemDefinition(SubsystemDefinition);
```

### Subclassing `USimpleBuff`

If you want to use your custom `USimpleBuff` subclass with the Coordinator, you will need to override the `USimpleBuffsCoordinator` and one of the following functions:

```c++
// USimpleBuffsCoordinator

virtual USimpleBuff* CreateBuff(FName BuffID);

// OR

virtual USimpleBuff* CreateBuffFromDefinition(FSimpleBuffDefinition* DefinitionReference);
```

**`CreateBuff`:**

```c++
USimpleBuff* USimpleBuffsCoordinator::CreateBuff(FName BuffID) {
    // Guard against nullptrs

    // Lookup `FSimpleBuffDefinition` by `BuffID` in the `DefinitionReference->BuffsTable`.
    // If you use the same value between Row Name & BuffID, you can do a direct row lookup instead of searching the data table.

    // Create `USimpleBuff` From table definition.
    return CreateBuffFromDefinition(TableDefinition);
}
```

This fully initializes a `USimpleBuff` object with all properties copied over from the `FSimpleBuffDefinition`. Override this function to augment the table lookup process, if necessary.

**`CreateBuffFromDefinition`:**

```c++
USimpleBuff* CreateBuffFromDefinition(FSimpleBuffDefinition* BuffDefinition) {
    // Create Custom Buff here
    auto* NewBuff = NewObject<USimpleBuff>(this);

    // Copy properties from definition
    NewBuff->InflateFromDefinitionReference(BuffDefinition);

    return NewBuff;
}
```

This function only creates the `USimpleBuff` object and passes over the `FSimpleBuffDefinition`. Override this function to only augment the buff creation process. The table lookups will function the same.

---

If overriding these lifecycle hooks does not meet the needs of your game, please create an issue on the [Github Issues](https://github.com/Ericdowney/SimpleBuffsExample/issues).