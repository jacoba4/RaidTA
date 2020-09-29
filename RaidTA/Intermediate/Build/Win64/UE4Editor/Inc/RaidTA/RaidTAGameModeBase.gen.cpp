// Copyright Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "RaidTA/RaidTAGameModeBase.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeRaidTAGameModeBase() {}
// Cross Module References
	RAIDTA_API UClass* Z_Construct_UClass_ARaidTAGameModeBase_NoRegister();
	RAIDTA_API UClass* Z_Construct_UClass_ARaidTAGameModeBase();
	ENGINE_API UClass* Z_Construct_UClass_AGameModeBase();
	UPackage* Z_Construct_UPackage__Script_RaidTA();
// End Cross Module References
	void ARaidTAGameModeBase::StaticRegisterNativesARaidTAGameModeBase()
	{
	}
	UClass* Z_Construct_UClass_ARaidTAGameModeBase_NoRegister()
	{
		return ARaidTAGameModeBase::StaticClass();
	}
	struct Z_Construct_UClass_ARaidTAGameModeBase_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_ARaidTAGameModeBase_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AGameModeBase,
		(UObject* (*)())Z_Construct_UPackage__Script_RaidTA,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_ARaidTAGameModeBase_Statics::Class_MetaDataParams[] = {
		{ "Comment", "/**\n * \n */" },
		{ "HideCategories", "Info Rendering MovementReplication Replication Actor Input Movement Collision Rendering Utilities|Transformation" },
		{ "IncludePath", "RaidTAGameModeBase.h" },
		{ "ModuleRelativePath", "RaidTAGameModeBase.h" },
		{ "ShowCategories", "Input|MouseInput Input|TouchInput" },
	};
#endif
	const FCppClassTypeInfoStatic Z_Construct_UClass_ARaidTAGameModeBase_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<ARaidTAGameModeBase>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_ARaidTAGameModeBase_Statics::ClassParams = {
		&ARaidTAGameModeBase::StaticClass,
		"Game",
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		nullptr,
		nullptr,
		UE_ARRAY_COUNT(DependentSingletons),
		0,
		0,
		0,
		0x009002ACu,
		METADATA_PARAMS(Z_Construct_UClass_ARaidTAGameModeBase_Statics::Class_MetaDataParams, UE_ARRAY_COUNT(Z_Construct_UClass_ARaidTAGameModeBase_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_ARaidTAGameModeBase()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_ARaidTAGameModeBase_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(ARaidTAGameModeBase, 1582935934);
	template<> RAIDTA_API UClass* StaticClass<ARaidTAGameModeBase>()
	{
		return ARaidTAGameModeBase::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_ARaidTAGameModeBase(Z_Construct_UClass_ARaidTAGameModeBase, &ARaidTAGameModeBase::StaticClass, TEXT("/Script/RaidTA"), TEXT("ARaidTAGameModeBase"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(ARaidTAGameModeBase);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
