# Advanced Usage

**SimpleBuffs** was built to be fully self-contained and work regardless of your game's architecture or set up. However, if you are in need of features not supported by the plugin and you are comfortable with C++, you can still use the various components of SimpleBuffs without using the full system. This guide will walk through an advanced usage of SimpleBuffs.

## **SimpleBuffs** Design

**SimpleBuffs** is set up with 3 layers.

* Subsystems (`USimpleBuffsSubsystem` & `USimpleBuffsTurnBasedSubsystem`)
* Coordinator (`USimpleBuffsCoordinator`)
* Buff (`USimpleBuff` & `FSimpleBuffDefinition`)

These three layers work to create the full functionality **SimpleBuffs** offers. Each layer is built to be standalone and work without the other. So in the event you need something different than what the plugin offers, you can:

* Use the Coordinator without the Subsystems
* Use the Buff without the Subsystems or the Coordinator
* Subclass `USimpleBuffsCoordinator` or `USimpleBuff` to augment its functionality.

**Please Note:** If you choose to use the Coordinator or Buff without the subsystems, you will need to manually tick they objects. Subsystems handle ticking for all managed objects.

## How to Subclass the Coordinator or Buff

Every public and protected function in the `USimpleBuffsCoordinator` and `USimpleBuff` is marked as `virtual` and can be overridden.

### Subclassing `USimpleBuffsCoordinator`

To use your custom `USimpleBuffsCoordinator` with the Subsystems, subclass and override the factory function on `USimpleBuffsCoordinatorFactory`:

```c++
// USimpleBuffsCoordinatorFactory
virtual USimpleBuffsCoordinator* CreateCoordinator(AActor* TargetActor) override;
```

This is used to create Coordinators within the Subsystems. Provide your custom factory to the subsystem by setting:

```c++
// USimpleBuffsSubsystem & USimpleBuffsTurnBasedSubsystem

UPROPERTY(BlueprintReadWrite, EditAnywhere, Category="Simple Buffs Subsystem")
USimpleBuffsCoordinatorFactory* CoordinatorFactory;
```

Inside `CreateCoordinator`, set up your custom Coordinator and ensure the target is set:

```c++
// USimpleBuffsCoordinatorFactory

USimpleBuffsCoordinator* USimpleBuffsCoordinatorFactory::CreateCoordinator(AActor* TargetActor) {
    auto* Coordinator = NewObject<USimpleBuffsCoordinator>(this); // Replace with custom coordinator class
    Coordinator->SetTarget(TargetActor);
    return Coordinator;
}
```

### Subclassing `USimpleBuff`

If you want to use your own custom `USimpleBuff` subclass with the Coordinator, override `USimpleBuffsCoordinator::CreateBuff` to return your subclass:

```c++
// USimpleBuffsCoordinator Header

virtual USimpleBuff* CreateBuff(FSimpleBuffDefinition BuffDefinition) override;
```

```c++
// USimpleBuffsCoordinator Implementation

USimpleBuff* USimpleBuffsCoordinator::CreateBuff(FSimpleBuffDefinition BuffDefinition) {
    auto* NewBuff = NewObject<USimpleBuff>(this); // Replace with custom buff class
    NewBuff->InflateFromDefinition(BuffDefinition);
    return NewBuff;
}
```

This fully initializes a `USimpleBuff` object with all properties copied over from the `FSimpleBuffDefinition`.

---

If overriding these lifecycle hooks does not work or does not meet the needs of your game, please create an issue on the [Github Issues](https://github.com/Ericdowney/SimpleBuffsExample/issues).

**Please Note:** Do **NOT** subclass the `USimpleBuffsSubsystem` or `USimpleBuffsTurnBasedSubsystem`. Unreal manages the lifecycle of these objects and creating a subclass will not override the subsystem. Instead, this would introduce a third subsystem.
