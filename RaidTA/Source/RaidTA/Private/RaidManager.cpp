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
		

	UE_LOG(LogTemp, Warning, TEXT("Init"));
	raid_size = raid_array.Num();
	selected_units.Init(false, raid_size);
}

// Called every frame
void ARaidManager::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}

void ARaidManager::SetupPlayerInputComponent(class UInputComponent* PlayerInputComponent)
{
	UE_LOG(LogTemp, Warning, TEXT("Input"));
	//Super::SetupPlayerInputComponent(InputComponent);
	InputComponent->BindAction("Select_Unit_0", IE_Pressed, this, &ARaidManager::SelectUnit0);
	InputComponent->BindAction("Select_Unit_1", IE_Pressed, this, &ARaidManager::SelectUnit1);
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

void ARaidManager::ClearSelection()
{
	for (int i = 0; i < selected_units.Num(); i++)
	{
		selected_units[i] = false;
	}
}


void ARaidManager::Click()
{
	APlayerController* playerController = UGameplayStatics::GetPlayerController(GetWorld(), 0);
	FHitResult hit;
	playerController->GetHitResultUnderCursor(ECollisionChannel::ECC_Visibility, false, hit);

	if (hit.GetActor()->GetName() == "Floor")
	{
		SendMouseCoordinate(hit.Location);
	}
	else if (hit.GetActor()->IsA< AUnit>())
	{
		SendNewTarget((AUnit*) hit.GetActor());
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

