// Fill out your copyright notice in the Description page of Project Settings.


#include "Encounter.h"
#include "Kismet/GameplayStatics.h"
#include "Engine/DecalActor.h"
#include "Components/DecalComponent.h"
#include "Math/UnrealMathUtility.h"

// Sets default values
AEncounter::AEncounter()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

}

// Called when the game starts or when spawned
void AEncounter::BeginPlay()
{
	Super::BeginPlay();
	SpawnRaid();
}

// Called every frame
void AEncounter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AEncounter::SpawnRaid()
{

}

void AEncounter::CastAoE(int spell_id, FVector location)
{

	FSpellInfo spell(spell_database->spells[spell_id]);
	ADecalActor* decal = GetWorld()->SpawnActor<ADecalActor>(spell.spell_blueprint, location, FRotator(90,0,0));
	if (decal)
	{
		
	}
	
}
FVector AEncounter::RandomPlayerLocation()
{
	int unit = FMath::RandRange(0, raid_manager->raid_size-1);
	FVector ret = raid_manager->raid_array[unit]->GetTransform().GetLocation();
	return ret;
}
