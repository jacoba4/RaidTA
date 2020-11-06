// Fill out your copyright notice in the Description page of Project Settings.


#include "RaidManager.h"

// Sets default values
ARaidManager::ARaidManager()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;
	AutoPossessPlayer = EAutoReceiveInput::Player0;
	
}

ARaidManager::~ARaidManager()
{

}

// Called when the game starts or when spawned
void ARaidManager::BeginPlay()
{
	Super::BeginPlay();
	raid_size = 0;
	raid_array = TArray<AUnit*>();

	UE_LOG(LogTemp, Warning, TEXT("Init"));	
}

// Called every frame
void ARaidManager::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ARaidManager::AddNewPlayer(TSubclassOf<AUnit> unit, FVector location)
{
	if (!unit)
	{
		return;
	}

	raid_size++;
	AUnit* new_unit = GetWorld()->SpawnActor<AUnit>(unit, location, FRotator(0));
	raid_array.Add(new_unit);
	selected_units.Add(false);
}

void ARaidManager::SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent)
{
	UE_LOG(LogTemp, Warning, TEXT("Input"));
	//Super::SetupPlayerInputComponent(InputComponent);
	InputComponent->BindAction("Select_Unit_0", IE_Pressed, this, &ARaidManager::SelectUnit0);
	InputComponent->BindAction("Select_Unit_1", IE_Pressed, this, &ARaidManager::SelectUnit1);
	InputComponent->BindAction("Select_Unit_2", IE_Pressed, this, &ARaidManager::SelectUnit2);
	InputComponent->BindAction("Select_Unit_3", IE_Pressed, this, &ARaidManager::SelectUnit3);
	InputComponent->BindAction("Select_Unit_4", IE_Pressed, this, &ARaidManager::SelectUnit4);
	InputComponent->BindAction("Select_Unit_5", IE_Pressed, this, &ARaidManager::SelectUnit5);
	InputComponent->BindAction("Select_Unit_6", IE_Pressed, this, &ARaidManager::SelectUnit6);
	InputComponent->BindAction("Select_Unit_7", IE_Pressed, this, &ARaidManager::SelectUnit7);
	InputComponent->BindAction("Select_Unit_8", IE_Pressed, this, &ARaidManager::SelectUnit8);
	InputComponent->BindAction("Select_Unit_9", IE_Pressed, this, &ARaidManager::SelectUnit9);
	InputComponent->BindAction("Click", IE_Pressed, this, &ARaidManager::Click);
}

void ARaidManager::SelectUnit(int index)
{
	if (index < 0 || index >= raid_size)
	{
		return;
	}
	ClearSelection();
	selected_units[index] = true;
	raid_array[index]->ControlUnit(true);
}

void ARaidManager::SelectUnit0()
{
	SelectUnit(0);
}
void ARaidManager::SelectUnit1()
{
	SelectUnit(1);
}
void ARaidManager::SelectUnit2()
{
	SelectUnit(2);
}
void ARaidManager::SelectUnit3()
{
	SelectUnit(3);
}
void ARaidManager::SelectUnit4()
{
	SelectUnit(4);
}
void ARaidManager::SelectUnit5()
{
	SelectUnit(5);
}
void ARaidManager::SelectUnit6()
{
	SelectUnit(6);
}
void ARaidManager::SelectUnit7()
{
	SelectUnit(7);
}
void ARaidManager::SelectUnit8()
{
	SelectUnit(8);
}
void ARaidManager::SelectUnit9()
{
	SelectUnit(9);
}


void ARaidManager::ClearSelection()
{
	for (int i = 0; i < selected_units.Num(); i++)
	{
		selected_units[i] = false;
		raid_array[i]->ControlUnit(false);
	}
}


void ARaidManager::Click()
{
	APlayerController* playerController = UGameplayStatics::GetPlayerController(GetWorld(), 0);
	FHitResult hit;
	playerController->GetHitResultUnderCursor(ECollisionChannel::ECC_Visibility, false, hit);
	AActor* hit_actor = hit.GetActor();

	if (hit_actor->IsA< AUnit>())
	{
		AUnit* hit_unit = (AUnit*)hit_actor;
		if (!hit_unit->is_player)
		{
			SendNewTarget(hit_unit);
		}
		else
		{
			FVector location(hit.Location.X, hit.Location.Y, 10);
			SendMouseCoordinate(location);
		}
	}
	else
	{
		FVector location(hit.Location.X, hit.Location.Y, 10);
		SendMouseCoordinate(location);
	}
	
}
void ARaidManager::SendMouseCoordinate(FVector location)
{
	for (int i = 0; i < raid_size; i++)
	{
		if (selected_units[i])
		{
			raid_array[i]->MoveToLocation(location);
		}
	}
}

void ARaidManager::SendNewTarget(AUnit *unit)
{
	for (int i = 0; i < raid_size; i++)
	{
		if (selected_units[i])
		{
			raid_array[i]->SetNewTarget(unit);
		}
	}
}

void ARaidManager::AddUnit(AUnit* unit)
{

}

