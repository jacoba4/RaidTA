// Fill out your copyright notice in the Description page of Project Settings.


#include "Encounter.h"
#include "Kismet/GameplayStatics.h"
#include "Kismet/KismetSystemLibrary.h"
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
	SpawnRaid();
	Super::BeginPlay();
	
}

// Called every frame
void AEncounter::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void AEncounter::SpawnRaid()
{
	if (!raid_manager_bp) { return; }
	raid_manager = GetWorld()->SpawnActor<ARaidManager>(raid_manager_bp, FVector(0, 0, 0), FRotator(0, 0, 0));
}

void AEncounter::CastSpell(int spell_id, FVector location)
{
	if (location == FVector(0.123456)) { return; }

	FSpellInfo spell(spell_database->spells[spell_id]);
	ADecalActor* decal = GetWorld()->SpawnActor<ADecalActor>(spell.spell_blueprint, location, FRotator(90,0,0));	
}
FVector AEncounter::RandomPlayerLocation()
{
	if (!raid_manager) { return FVector(0.123456); }

	if (raid_manager->raid_array.Num() == 0) {return FVector(0.123456);}

	int unit = FMath::RandRange(0, raid_manager->raid_size - 1);
	if (!raid_manager->raid_array[unit]) { return FVector(0.123456); }

	FVector ret = raid_manager->raid_array[unit]->GetTransform().GetLocation();
	return ret;
}

void AEncounter::AddNewPlayer(int index, FVector location)
{
	if (index < 0 || index > unit_database->units.Num() - 1 || !raid_manager)
	{
		GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Red, TEXT("AddNewPlayers"));
		return;
	}
	
	raid_manager->AddNewPlayer(unit_database->units[index], location);
}

void AEncounter::AddNewPlayers(TArray<int> indexes, TArray<FVector> locations)
{
	if (indexes.Num() != locations.Num())
	{
		GEngine->AddOnScreenDebugMessage(-1, 5.f, FColor::Red, TEXT("AddNewPlayers: Indexes/locations size invalid"));
		return;
	}

	for (int i = 0; i < indexes.Num(); i++)
	{
		int index = indexes[i];
		FVector location = locations[i];
		AddNewPlayer(index, location);
	}
}

void AEncounter::AddNewNPC(TSubclassOf<ANPC> npc, FVector location)
{
	if (!npc)
	{
		return;
	}

	ANPC* spawned = GetWorld()->SpawnActor<ANPC>(npc, location, FRotator(0));
	spawned->InitTable(raid_manager->raid_array);
}

void AEncounter::AddNewUnit(TSubclassOf<AUnit> unit, FVector location)
{
	if (!unit)
	{
		return;
	}

	AUnit* spawned = GetWorld()->SpawnActor<AUnit>(unit, location, FRotator(0));
}
