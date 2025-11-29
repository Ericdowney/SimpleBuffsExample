# API Reference

This document provides a reference for all public classes, structs, properties, functions, interfaces, and events exposed by the **SimpleBuffs** runtime plugin.

## **Modules**

* **SimpleBuffs** - Runtime module containing all buff logic (buffs, coordinators, subsystems, interfaces, and data definitions).

# **Classes**

## **USimpleBuff**

Represents a single active buff instance applied to a target actor. Buffs may be time-based ("Over Time") or Persistent.

### **Events**

* `FOnBuffEvent OnApplyBuff`
* `FOnBuffEvent OnBuffStacksUpdated`
* `FOnBuffEvent OnBuffExpiration`

### **Properties**

* `FName BuffID`
* `FName BuffCategory`
* `FText BuffName`
* `FText BuffDescription`
* `TSoftObjectPtr<UTexture2D> BuffIcon`
* `ESimpleBuffsApplicationType ApplicationType`
* `ESimpleBuffsRefreshPolicy RefreshPolicy`
* `bool bApplyImmediately`
* `int32 MaxStacks`
* `float Duration`
* `float TickInterval`
* `ESimpleBuffsSignType SignType`
* `ESimpleBuffsValueType ValueType`
* `float ValueMagnitude`
* `FDataTableRowHandle BuffMetadataRowHandle`

### **Public Functions**

* `float GetTimeRemaining() const`
* `float GetTimeUntilNextTick() const`
* `float GetAccumulatedTime() const`
* `float GetLastExecutedTime() const`
* `int32 GetNumberOfStacks() const`
* `bool IsExpired() const`
* `bool ShouldApplyImmediately() const`
* `void ApplyStacks(int32 StacksToApply = 1)`
* `void Refresh()`
* `void ProcessTick(float DeltaTime)`
* `void InflateFromDefinition(FSimpleBuffDefinition Definition)`

## **USimpleBuffsCoordinator**

### **Events**

* `FOnBuffEvent OnApplyBuff`
* `FOnBuffEvent OnBuffStacksUpdated`
* `FOnBuffEvent OnRemoveBuff`

### **Properties**

* `TWeakObjectPtr<AActor> TargetActor`
* `TSet<USimpleBuff*> ActiveBuffs`
* `TSet<USimpleBuff*> PendingAdditions`
* `TSet<USimpleBuff*> PendingRemovals`

### **Public Functions**

* `bool HasBuff(FName BuffID) const`
* `USimpleBuff* GetBuff(FName BuffID) const`
* `TSet<USimpleBuff*> GetAllBuffs() const`
* `TSet<USimpleBuff*> GetAllBuffsByCategory(FName BuffCategory) const`
* `AActor* GetTarget() const`
* `bool IsEmpty() const`
* `void ProcessTick(float DeltaTime)`
* `void SetTarget(AActor* InTargetActor)`
* `USimpleBuff* ApplyBuff(FSimpleBuffDefinition BuffDefinition, int32 StacksToApply = 1)`
* `USimpleBuff* RefreshBuff(FName BuffID)`
* `USimpleBuff* RemoveBuffStacks(FName BuffID, int32 StacksToRemove = 1)`
* `USimpleBuff* RemoveBuff(FName BuffID)`
* `void RemoveAllBuffs()`

## **USimpleBuffsCoordinatorFactory**

### **Public Functions**

* `USimpleBuffsCoordinator* CreateCoordinator(AActor* TargetActor)`

## **USimpleBuffsSubsystem**

### **Events**

* `FOnBuffEvent OnApplyBuff`
* `FOnBuffEvent OnBuffStacksUpdated`
* `FOnBuffEvent OnRemoveBuff`

### **Public Functions**

* `bool IsPaused() const`
* `bool IsRunning() const`
* `bool HasAnyBuffs(AActor* TargetActor) const`
* `bool HasBuff(AActor* TargetActor, FName BuffID) const`
* `USimpleBuff* GetBuff(AActor* TargetActor, FName BuffID) const`
* `TSet<USimpleBuff*> GetAllBuffsForTarget(AActor* TargetActor) const`
* `USimpleBuffsCoordinator* GetBuffCoordinator(AActor* TargetActor) const`
* `TArray<USimpleBuffsCoordinator*> GetAllBuffCoordinators() const`
* `void Pause()`
* `void Resume()`
* `USimpleBuff* ApplyBuff(AActor* TargetActor, FSimpleBuffDefinition BuffDefinition, int32 StacksToApply = 1)`
* `USimpleBuff* RefreshBuff(AActor* TargetActor, FName BuffID)`
* `USimpleBuff* RemoveBuffStacks(AActor* TargetActor, FName BuffID, int32 StacksToRemove = 1)`
* `USimpleBuff* RemoveBuff(AActor* TargetActor, FName BuffID)`
* `void RemoveAllBuffsOnTarget(AActor* TargetActor)`
* `void RemoveAllBuffs()`

## **USimpleBuffsTurnBasedSubsystem**

### **Events**

* `FOnApplyBuffEvent OnApplyBuff`
* `FOnApplyBuffEvent OnBuffStacksUpdated`
* `FOnApplyBuffEvent OnRemoveBuff`

### **Public Functions**

* `bool HasAnyBuffs(AActor* TargetActor) const`
* `bool HasBuff(AActor* TargetActor, FName BuffID) const`
* `USimpleBuff* GetBuff(AActor* TargetActor, FName BuffID) const`
* `TSet<USimpleBuff*> GetAllBuffsForTarget(AActor* TargetActor) const`
* `USimpleBuffsCoordinator* GetBuffCoordinator(AActor* TargetActor) const`
* `TArray<USimpleBuffsCoordinator*> GetAllBuffCoordinators() const`
* `void AdvanceTurn(int32 Turns = 1)`
* `USimpleBuff* ApplyBuff(AActor* TargetActor, FSimpleBuffDefinition BuffDefinition, int32 StacksToApply = 1)`
* `USimpleBuff* RefreshBuff(AActor* TargetActor, FName BuffID)`
* `USimpleBuff* RemoveBuffStacks(AActor* TargetActor, FName BuffID, int32 StacksToRemove = 1)`
* `USimpleBuff* RemoveBuff(AActor* TargetActor, FName BuffID)`
* `void RemoveAllBuffsOnTarget(AActor* TargetActor)`
* `void RemoveAllBuffs()`

# **Interfaces**

## **ISimpleBuffsTarget**

### **Functions**

* `void ApplyBuff(USimpleBuff* InBuff)`
* `void BuffStacksUpdated(USimpleBuff* InBuff)`
* `void RemoveBuff(USimpleBuff* InBuff)`

# **Structs**

## **FSimpleBuffDefinition**

### **Fields**

* Buff identifiers, name, description, icon
* ApplicationType, RefreshPolicy, MaxStacks
* Duration, TickInterval
* SignType, ValueType, ValueMagnitude
* BuffMetadataRowHandle

# **Enums**

## **ESimpleBuffsApplicationType**

* `OverTime`
* `Persistent`

## **ESimpleBuffsRefreshPolicy**

* `DoNotRefresh`
* `RefreshDuration`
* `Extend`

## **ESimpleBuffsSubsystemState**

* `Running`
* `Paused`

## **ESimpleBuffsSignType**

* `Positive`
* `Negative`

## **ESimpleBuffsValueType**

* `Absolute`
* `Percentage`