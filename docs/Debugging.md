# Debugging

**SimpleBuffs** includes an Editor Utility to view your game's active buffs while running in PIE.

![Simple Buffs Editor UI](./Images/EditorUI.png)

To open the editor, navigate to `Window -> Simple Buffs`. Once buffs are applied to actors in PIE, they will appear in the UI.

## Editor Features

By default, the editor shows a Search Field, a Refresh Button, and a dropdown menu with a few options:

* **Search:** Search by buff name.
* **Refresh:** Finds buffs and displays them. Buffs only show while running in PIE.
* **Automatic Refresh:** Polls every 0.1 seconds.
* **Verbose Logging:** Sends editor logs to the Output Log. Enable if buffs are not displaying.

If buffs do not appear:

* Confirm you are running in PIE.
* Ensure buffs are applied to actors that exist in the current world.
* Click **Refresh** (or enable **Automatic Refresh**) while PIE is active.
* Check the Output Log with verbose logging enabled for errors.

## Debugging An Issue

### Logs

If **SimpleBuffs** is not tracking buffs properly, enable the logs in your project. Open your project's `DefaultEngine.ini` file and add:

```ini
[Core.Log]
SimpleBuffsLog=Verbose
SimpleBuffsEditorLog=Verbose
```

These categories surface internal logs for **SimpleBuffs** and the editor. Use them to trace the execution path and identify issues.

### Issues & Support

If you diagnose a problem with **SimpleBuffs**, are unable to get it working properly, or have a new feature request, please add an issue to the [Github Issue Tracker](https://github.com/Ericdowney/SimpleBuffsExample/issues).
