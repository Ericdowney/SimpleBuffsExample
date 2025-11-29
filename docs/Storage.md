# Storage

Buffs are transient entities and there is no provided mechanism for storage. This is by design: buffs are not meant to be persisted in a save game file. Over-Time buffs naturally expire, but Persistent buffs require you to persist why they exist and reapply them when appropriate.

## What to Persist

Persist the **source or reason** for a Persistent buff (e.g., equipped gear, passive skills, quest state), not the buff instance itself. On load, inspect that state and reapply the corresponding buffs.

## Level Transitions & Relaunches

Buffs are tied to actor instances. On level transition or relaunch:

- Recreate the relevant actor.
- Reapply Persistent buffs based on your persisted sources.
- Let Over-Time buffs start fresh unless your game design demands otherwise.
