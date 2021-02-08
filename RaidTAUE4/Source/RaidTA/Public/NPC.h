// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Unit.h"
#include "NPC.generated.h"

/**
 * 
 */
UCLASS()
class RAIDTA_API ANPC : public AUnit
{
	GENERATED_BODY()
	ANPC();
public:
	virtual void BeginPlay() override;
	void InitTable(TArray<AUnit*> units);
	void AddThreat(AUnit* unit, float threat);
	void Taunt(AUnit* unit);
	void CheckThreat();
	void TableSortValue();


	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Threat")
	TMap<AUnit*, float> threat_table;
};
