using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CP.Guido 
{
	public class ColorizeImageInChildren : MonoBehaviour 
	{
		public bool autoUpdate = false;

		public List<Image> imagesToExclude = new List<Image>();

		[SerializeField]
		private Color m_color = Color.white;

		public Color color 
		{
			set	{ 
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
			Image[] images = gameObject.GetComponentsInChildren<Image>(true);
			foreach (Image image in images) 
			{
				if(image != null && !imagesToExclude.Contains(image))
				{
					image.color = m_color;
				}
			}
		}

		void Start () 
		{
			ChangeColor();
		}
	}//class

} //namespace