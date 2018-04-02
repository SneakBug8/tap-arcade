using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CP.Guido 
{
	public class ColorizeImage : MonoBehaviour 
	{
		public bool autoUpdate = false;

		public List<Image> imagesToColorize = new List<Image>();
		
		[SerializeField]
		private Color m_color = Color.white;

		public Color color 
		{
			set	
			{ 
				m_color = value;
				if(imagesToColorize.Count != 0) 
				{
					ChangeColor();
				}	
			}
		}

	#if UNITY_EDITOR
		void OnValidate()
		{
			if(imagesToColorize.Count != 0 && autoUpdate) 
			{
				ChangeColor();
			}
		}
	#endif

		public void ChangeColor() 
		{
			foreach (Image image in imagesToColorize) 
			{
				if(image != null)
				{
					image.color = m_color;
				}
			}
		}

		void Start () 
		{
			if(imagesToColorize.Count != 0) 
			{
				ChangeColor();
			}
		}
	}//class

} //namespace
