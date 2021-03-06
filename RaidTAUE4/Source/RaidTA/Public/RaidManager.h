// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Unit.h"
#include "Components/InputComponent.h"
#include "Kismet/GameplayStatics.h"

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "RaidManager.generated.h"


UCLASS()
class RAIDTA_API ARaidManager : public APawn
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	ARaidManager();
	~ARaidManager();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;
	
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent);
	void SelectUnit(int index);
	void SelectUnit0();
	void SelectUnit1();
	void SelectUnit2();
	void SelectUnit3();
	void SelectUnit4();
	void SelectUnit5();
	void SelectUnit6();
	void SelectUnit7();
	void SelectUnit8();
	void SelectUnit9();
	void ClearSelection();
	void Click();
	void SendMouseCoordinate(FVector location);
	void SendNewTarget(AUnit *unit);
	void AddUnit(AUnit* unit);

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
	void AddNewPlayer(TSubclassOf<AUnit> unit, FVector location);

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int raid_size;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	TArray<AUnit*> raid_array;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	TArray<bool> selected_units;
};
