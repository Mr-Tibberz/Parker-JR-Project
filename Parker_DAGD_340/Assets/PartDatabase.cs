using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


[XmlRoot("PartCollection")]
public class PartDatabase {

	[XmlArray("Parts")]
	[XmlArrayItem("Part")]
	public List<Part> parts = new List<Part>();


	public static PartDatabase LoadPartData() 
	{
        FileStream fs = new FileStream(Application.dataPath + "/StreamingAssets/XML/data.xml", FileMode.Open);
		XmlSerializer serializer = new XmlSerializer(typeof(PartDatabase));
        PartDatabase parts = serializer.Deserialize(fs) as PartDatabase;
		fs.Close();
		return parts;
	}
}
