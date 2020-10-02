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
	InputComponent->BindAction("Click", IE_Pressed, this, &ARaidManager::SendMouseCoordinate);
}
void ARaidManager::SelectUnit0()
{
	UE_LOG(LogTemp, Warning, TEXT("SelectUnit0"));
	ClearSelection();
	selected_units[0] = true;
}

void ARaidManager::SelectUnit1()
{
	ClearSelection();
	selected_units[1] = true;
}

void ARaidManager::ClearSelection()
{
	for (int i = 0; i < selected_units.Num(); i++)
	{
		selected_units[i] = false;
	}
}

void ARaidManager::SendMouseCoordinate()
{
	APlayerController* playerController = UGameplayStatics::GetPlayerController(GetWorld(), 0);
	FHitResult hit;
	playerController->GetHitResultUnderCursor(ECollisionChannel::ECC_Visibility, false, hit);
	
	for (int i = 0; i < raid_size; i++)
	{
		if (selected_units[i])
		{
			raid_array[i]->MoveToLocation(hit.Location);
		}
	}
}

