using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CP.Guido 
{
	public class ColorizeTextInChildren : MonoBehaviour 
	{
		public bool autoUpdate = false;

		public List<Text> textsToExclude = new List<Text>();

		[SerializeField]
		private Color m_color = Color.white;

		public Color color 
		{
			set	
			{ 
				m_color = value;
				ChangeColor();
			}
		}

	#if UNITY_EDITOR
		void OnValidate()
		{
			if(autoUpdate)
			{
				ChangeColor();
			}
		}
	#endif

		public void ChangeColor() 
		{
			Text[] texts = gameObject.GetComponentsInChildren<Text>(true);
			foreach (Text text in texts) 
			{
				if(text != null && !textsToExclude.Contains(text))
				{
					text.color = m_color;
				}
			}
		}

		void Start () 
		{
			ChangeColor();
		}
	} //class

} //namespace