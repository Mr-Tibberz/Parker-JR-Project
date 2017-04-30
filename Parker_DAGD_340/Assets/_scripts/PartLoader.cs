using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartLoader : MonoBehaviour {

	public const string path = "data";
    public PartDatabase partDB;

	void Start () {
        partDB = PartDatabase.LoadPartData();
	}
	public Part FindPart(string partnum) {
		Part toReturn = null;
		
		foreach(Part part in partDB.parts)
		{
			if(part.number == partnum) toReturn = part;
		}
		return toReturn;
	}
}
