﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Part {


    [XmlElement("PartNumber")]
    public string number;

    [XmlElement("Info")]
    public string info;

}
