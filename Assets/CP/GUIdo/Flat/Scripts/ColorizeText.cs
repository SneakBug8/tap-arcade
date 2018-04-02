using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CP.Guido 
{
	public class ColorizeText : MonoBehaviour 
	{
		public bool autoUpdate = false;

		public List<Text> textsToColorize = new List<Text>();
		
		[SerializeField]
		private Color m_color = Color.white;

		public Color color {
			set	{ 
				m_color = value;
				if(textsToColorize.Count != 0) 
				{
					ChangeColor();
				}	
			}
		}

	#if UNITY_EDITOR
		void OnValidate()
		{
			if(textsToColorize.Count != 0 && autoUpdate) 
			{
				ChangeColor();
			}
		}
	#endif

		public void ChangeColor() 
		{
			foreach (Text text in textsToColorize) 
			{
				if(text != null)
				{
					text.color = m_color;
				}
			}
		}

		void Start() 
		{
			if(textsToColorize.Count != 0) 
			{
				ChangeColor();
			}
		}
	
	} //class

} //namespace
