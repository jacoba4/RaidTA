// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Pawn.h"
#include "Unit.generated.h"

UCLASS()
class RAIDTA_API AUnit : public APawn
{
	GENERATED_BODY()

public:
	// Sets default values for this pawn's properties
	AUnit();
	~AUnit();

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;

	// Called to bind functionality to input
	virtual void SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent) override;

	// Called to teleport a Unit to a location
	void MoveToLocation(FVector MoveLocation);

private:
	int max_hp;
	int hp;
	int damage;
	bool is_healer;
	bool has_command; // Move this to Player Unit class when made?
	FVector target_destination;
	AUnit* current_target;
};
