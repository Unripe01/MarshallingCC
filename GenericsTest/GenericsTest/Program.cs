using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsTest
{
	class Program
	{
		static void Main( string[] args )
		{

		}

　　private static bool GetXlmValue<T>( string xmlPath, string element , ref T value )
　　{
			Type t = typeof( T );
			
			value.GetType().GetMember( "TryParse" );
			System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
			doc.Load(xmlPath);
			return true;
　　}

	}
}
