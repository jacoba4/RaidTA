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

	if (this->has_command) {
		FVector destinationLocation = FMath::VInterpConstantTo(this->GetActorLocation(), this->target_destination, DeltaTime, this->move_speed);
		this->SetActorLocation(destinationLocation);

		if (this->GetActorLocation() == this->target_destination) {
			this->has_command = false;
		}
	}
	else if (!this->has_command && this->current_target) {
		float distance = this->GetDistanceTo(this->current_target);
		if (distance > this->range) {
			FVector targetVector = this->current_target->GetActorLocation() - this->GetActorLocation();
			targetVector.Normalize();
			FVector scaledLocation = targetVector * (-1 * this->range) + this->current_target->GetActorLocation();
			this->MoveToLocation(scaledLocation);
		}
		else {
			if (this->attack_countdown <= 0) {
				this->AttackUnit(this->current_target);
				this->attack_countdown = this->attack_speed;
			}
			else {
				this->attack_countdown -= DeltaTime;
			}
		}
	}

	if (this->has_command || !this->current_target) {
		this->attack_countdown = this->attack_speed;
	}
}

// Called to bind functionality to input
void AUnit::SetupPlayerInputComponent(UInputComponent* PlayerInputComponent)
{
	Super::SetupPlayerInputComponent(PlayerInputComponent);
}

void AUnit::MoveToLocation(FVector MoveLocation)
{
	this->target_destination = MoveLocation;
	this->has_command = true;
}

float AUnit::TakeDamage(float DamageAmount, struct FDamageEvent const& DamageEvent,
	class AController* EventInstigator, class AActor* DamageCauser)
{
	this->hp -= DamageAmount;
	this->CallSetPercent();
	return DamageAmount;
}

void AUnit::AttackUnit(AUnit* Target)
{
	FHitResult HitResult = FHitResult(this->GetActorLocation(), Target->GetActorLocation());
	FPointDamageEvent DamageEvent = FPointDamageEvent(this->damage, HitResult, this->GetActorLocation(), UDamageType::StaticClass());
	Target->TakeDamage(this->damage, DamageEvent, this->GetController(), this);
	// Potential expansion for skills with different damage values, status effects, etc.
}

void AUnit::SetNewTarget(AUnit* NewTarget)
{
	if (NewTarget != this)
		this->current_target = NewTarget;
}

void AUnit::CastAoE(int spell_id, FVector location)
{
	
}

