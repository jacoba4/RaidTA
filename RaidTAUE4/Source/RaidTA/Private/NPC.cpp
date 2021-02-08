// Fill out your copyright notice in the Description page of Project Settings.


#include "NPC.h"
ANPC::ANPC()
{
	PrimaryActorTick.bCanEverTick = true;
}

void ANPC::BeginPlay()
{
	Super::BeginPlay();
}

void ANPC::InitTable(TArray<AUnit*> units)
{
	for (int i = 0; i < units.Num(); i++)
	{
		if (!units[i])
		{
			continue;
		}
		threat_table.Add(units[i], 0);
	}
}

void ANPC::AddThreat(AUnit* unit, float threat)
{
	if (!unit)
	{
		return;
	}
	float current = *threat_table.Find(unit);
	threat_table.Add(unit, current + threat);
	CheckThreat();
}

void ANPC::Taunt(AUnit* unit)
{
	if (!unit)
	{
		return;
	}

	float current_threat = *threat_table.Find(unit);
	

	TableSortValue();

	float max_threat = threat_table[0];
	float goal_threat = max_threat * 1.31;

	AddThreat(unit, goal_threat - current_threat);
	CheckThreat();
}

void ANPC::CheckThreat()
{
	TableSortValue();
	AUnit* top_unit = threat_table.CreateConstIterator().Key();
	float top_unit_threat = threat_table[0];

	if (!current_target)
	{
		if (threat_table[0] > 0)
		{
			current_target = top_unit;
		}
		else
		{
			return;
		}
	}
	else
	{
		if (top_unit != current_target)
		{
			float current_threat = *threat_table.Find(current_target);
			if (GetDistanceTo(top_unit) > range)
			{
				if (current_threat * 1.3 < top_unit_threat)
				{
					current_target = top_unit;
				}
			}
			else
			{
				if (current_threat * 1.1 < top_unit_threat)
				{
					current_target = top_unit;
				}
			}
		}
	}
}

void ANPC::TableSortValue()
{
	threat_table.ValueSort([](const float& A, const float& B) {
		return A < B;
		});
}