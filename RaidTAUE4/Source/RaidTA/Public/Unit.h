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

	
	// Overriden function to handle damage
	UFUNCTION(BlueprintCallable, Category = "My Functions")
	virtual float TakeDamage(float DamageAmount, struct FDamageEvent const& DamageEvent,
		class AController* EventInstigator, class AActor* DamageCauser) override;

	float TakeHealing(float HealAmount, struct FDamageEvent const& DamageEvent,
		class AController* EventInstigator, class AActor* HealCauser);

	// Called to teleport a Unit to a location
	void MoveToLocation(FVector MoveLocation);

	void AttackUnit(AUnit* Target);

	void HealUnit(AUnit* Target);

	void SetNewTarget(AUnit* NewTarget);

	UFUNCTION(BlueprintImplementableEvent, Category = "Status")
	void CallSetPercent();

	void ControlUnit(bool CanControl);

	void CastAoE(int spell_id, FVector location);

	void SendThreatDamage(float DamageDone);

	void IncreaseThreat(AUnit* Instigator, float ThreatValue);
	
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int max_hp;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int hp;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int damage;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int healing;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	int threat_mod;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	bool is_healer;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	bool is_player;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	bool is_dead;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	float attack_speed;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	float range;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	bool has_command;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	float attack_countdown;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	float move_speed;
	UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	AUnit* current_target;
	//UPROPERTY(BlueprintReadWrite, EditAnywhere, Category = "Raid")
	//AEncounter* encounter;

	UPROPERTY(BlueprintReadOnly, VisibleAnywhere, Category = "Raid")
	FVector target_destination;

	
};
