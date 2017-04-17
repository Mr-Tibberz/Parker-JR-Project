using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartLoader : MonoBehaviour {

	public const string path = "data";
    public PartDatabase partDB;

	void Start () {
        partDB = PartDatabase.LoadPartData();
		foreach(Part part in partDB.parts)
		{
			print(part.name);
		}
	}

}
