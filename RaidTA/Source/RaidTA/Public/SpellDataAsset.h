// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "SpellDataAsset.generated.h"

/**
 * 
 */
USTRUCT()
struct FSpellInfo
{
	GENERATED_USTRUCT_BODY()
	UPROPERTY(EditAnywhere)
	FString spell_name;

	UPROPERTY(EditAnywhere)
	float radius;

	UPROPERTY(EditAnywhere)
	float duration;

};
UCLASS()
class RAIDTA_API USpellDatabase : public UDataAsset
{
	GENERATED_BODY()
public:
	UPROPERTY(EditAnywhere)
	TArray<FSpellInfo> spells;
};
