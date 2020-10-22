// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Unit.h"
#include "CoreMinimal.h"
#include "Engine/DataAsset.h"
#include "UnitDatabase.generated.h"

/**
 * 
 */
UCLASS()
class RAIDTA_API UUnitDatabase : public UDataAsset
{
	GENERATED_BODY()

	UPROPERTY(EditAnywhere)
	TArray<TSubclassOf<AUnit> > units;
};
