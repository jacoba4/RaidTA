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
	void SelectUnit0();
	void SelectUnit1();
	void ClearSelection();
	void SendMouseCoordinate();

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int raid_size;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	TArray<AUnit*> raid_array;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	TArray<bool> selected_units;
};
