using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Part {

	[XmlElement("Name")]
    public string name;

    [XmlElement("PartNumber")]
    public string partnumber;

    [XmlElement("Info")]
    public string info;

}
