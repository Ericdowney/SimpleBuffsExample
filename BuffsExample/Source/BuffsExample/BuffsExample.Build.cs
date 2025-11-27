// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class BuffsExample : ModuleRules
{
	public BuffsExample(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] {
			"Core",
			"CoreUObject",
			"Engine",
			"InputCore",
			"EnhancedInput",
			"AIModule",
			"StateTreeModule",
			"GameplayStateTreeModule",
			"UMG",
			"Slate"
		});

		PrivateDependencyModuleNames.AddRange(new string[] { });

		PublicIncludePaths.AddRange(new string[] {
			"BuffsExample",
			"BuffsExample/Variant_Platforming",
			"BuffsExample/Variant_Platforming/Animation",
			"BuffsExample/Variant_Combat",
			"BuffsExample/Variant_Combat/AI",
			"BuffsExample/Variant_Combat/Animation",
			"BuffsExample/Variant_Combat/Gameplay",
			"BuffsExample/Variant_Combat/Interfaces",
			"BuffsExample/Variant_Combat/UI",
			"BuffsExample/Variant_SideScrolling",
			"BuffsExample/Variant_SideScrolling/AI",
			"BuffsExample/Variant_SideScrolling/Gameplay",
			"BuffsExample/Variant_SideScrolling/Interfaces",
			"BuffsExample/Variant_SideScrolling/UI"
		});

		// Uncomment if you are using Slate UI
		// PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		// Uncomment if you are using online features
		// PrivateDependencyModuleNames.Add("OnlineSubsystem");

		// To include OnlineSubsystemSteam, add it to the plugins section in your uproject file with the Enabled attribute set to true
	}
}
