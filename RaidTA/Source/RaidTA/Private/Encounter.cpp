// Fill out your copyright notice in the Description page of Project Settings.


#include "Encounter.h"
#include "Kismet/GameplayStatics.h"
#include "Engine/DecalActor.h"
#include "Components/DecalComponent.h"

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
	CastAoE(0, FVector(0, 0, 10));
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
	ADecalActor* decal = GetWorld()->SpawnActor<ADecalActor>(location, FRotator());
	if (decal)
	{
		decal->SetDecalMaterial(indicator_material);
		decal->SetLifeSpan(spell.duration);
		decal->GetDecal()->DecalSize = FVector(spell.radius);
	}
	
}
void AEncounter::RandomPlayerLocation()
{

}
