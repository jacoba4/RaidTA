// Fill out your copyright notice in the Description page of Project Settings.


#include "Unit.h"

// Sets default values
AUnit::AUnit()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

AUnit::~AUnit()
{
}

// Called when the game starts or when spawned
void AUnit::BeginPlay()
{
	Super::BeginPlay();
	this->attack_countdown = this->attack_speed;
}

// Called every frame
void AUnit::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

	if (!this->has_command && this->attack_countdown <= 0 && this->current_target) {
		this->AttackUnit(this->current_target);
		this->attack_countdown = this->attack_speed;
	} else if (!this->has_command && this->attack_countdown > 0) {
		this->attack_countdown -= DeltaTime;
	}
}

// Called to bind functionality to input
void AUnit::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);

}

void AUnit::MoveToLocation(FVector MoveLocation)
{
	// Teleportation currently, think about other movement methods
	SetActorLocation(MoveLocation);
}

void AUnit::AttackUnit(AUnit* Target)
{
	Target->hp -= this->damage;
	// Potential expansion for skills with different damage values, status effects, etc.
}

void AUnit::SetNewTarget(AUnit* NewTarget)
{
	this->current_target = NewTarget;
}

