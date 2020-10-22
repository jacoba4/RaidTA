// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "RaidManager.h"
#include "SpellDataAsset.h"
#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "Encounter.generated.h"


UCLASS()
class RAIDTA_API AEncounter : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AEncounter();
	void SpawnRaid();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
	void CastAoE(int spell_id, FVector location);
	void RandomPlayerLocation();

	UPROPERTY(EditAnywhere)
	USpellDatabase* spell_database;

	UPROPERTY(EditAnywhere)
	ARaidManager* raid_manager;

	UPROPERTY(EditAnywhere)
	UMaterial* indicator_material;
};
