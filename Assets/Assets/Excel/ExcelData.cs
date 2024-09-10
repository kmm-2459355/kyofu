using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExcelAsset]
public class ExcelData : ScriptableObject
{
	public List<CharacterDataEntity> Character; // Replace 'EntityType' to an actual type that is serializable.
	public List<ObstacleDataEntity> Obstacle; // Replace 'EntityType' to an actual type that is serializable.
}
