// Fill out your copyright notice in the Description page of Project Settings.




#pragma once
class ARaidManager;
class AUnit;

#include "UnitDatabase.h"
#include "NPC.h"
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
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	void CastSpell(int spell_id, FVector location);
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	FVector RandomPlayerLocation();
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	void AddNewPlayer(int index, FVector location);
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	void AddNewPlayers(TArray<int> indexes, TArray<FVector> locations);
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	void AddNewNPC(TSubclassOf<ANPC> npc, FVector location);
	UFUNCTION(BlueprintCallable, Category = "Encounter")
	void AddNewUnit(TSubclassOf<AUnit> unit, FVector location);

	UPROPERTY(EditAnywhere, Category = "Data")
	USpellDatabase* spell_database;
	UPROPERTY(EditAnywhere, Category = "Data")
	UUnitDatabase* unit_database;
	UPROPERTY(EditAnywhere, Category = "Data")
	TSubclassOf<ARaidManager> raid_manager_bp;
	UPROPERTY(EditAnywhere, Category = "Data")
	int raid_size;


	UPROPERTY(EditAnywhere)
	ARaidManager* raid_manager;
	

};