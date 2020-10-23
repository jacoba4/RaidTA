// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Encounter.h"
#include "test_encounter.generated.h"

/**
 * 
 */
UCLASS()
class RAIDTA_API Atest_encounter : public AEncounter
{
	GENERATED_BODY()
	
public:
	Atest_encounter();

protected:
	virtual void BeginPlay() override;

public:
	
};
