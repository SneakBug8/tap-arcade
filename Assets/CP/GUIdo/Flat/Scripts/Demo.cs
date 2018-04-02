using UnityEngine;
using UnityEngine.UI;

using CP.Guido;

public class Demo : MonoBehaviour {

	public ColorizeImageInChildren colorizeImage;
	public CP.Guido.ColorizeText colorizeTextA;	
	public CP.Guido.ColorizeText colorizeTextB;	
	public CP.Guido.ColorizeText colorizeTextC;	
	
	public Color blue;
	public Color blueA;
	public Color blueB;
	public Color blueC;

	public Color purple;
	public Color purpleA;
	public Color purpleB;
	public Color purpleC;

	public Color grey;
	public Color greyA;
	public Color greyB;
	public Color greyC;

	public Color red;
	public Color redA;
	public Color redB;
	public Color redC;

	public Color green;
	public Color greenA;
	public Color greenB;
	public Color greenC;

	public Color yellow;
	public Color yellowA;
	public Color yellowB;
	public Color yellowC;

	private Color m_selectedImageColor;
	private Color m_selectedTextA_Color;
	private Color m_selectedTextB_Color;
	private Color m_selectedTextC_Color;

	void Start()
	{
		//check the drop links
		if(colorizeImage == null)
		{
			Debug.LogError("Missing colorizeImage link in demo!");
		} 
		if(colorizeTextA == null)
		{
			Debug.LogError("Missing colorizeTextA link in demo!");
		} 
		if(colorizeTextB == null)
		{
			Debug.LogError("Missing colorizeTextB link in demo!");
		} 
		if(colorizeTextC == null)
		{
			Debug.LogError("Missing colorizeTextC link in demo!");
		} 
		ChangeColor("blue");
	}

	public void ChangeColor(string color)
	{
		switch(color) {
			case "blue":
				m_selectedImageColor = blue;
				m_selectedTextA_Color = blueA;
				m_selectedTextB_Color = blueB;
				m_selectedTextC_Color = blueC;
				break;
			case "purple":
				m_selectedImageColor = purple;
				m_selectedTextA_Color = purpleA;
				m_selectedTextB_Color = purpleB;
				m_selectedTextC_Color = purpleC;
				break;	
			case "grey":
				m_selectedImageColor = grey;
				m_selectedTextA_Color = greyA;
				m_selectedTextB_Color = greyB;
				m_selectedTextC_Color = greyC;
				break;	
			case "red":
				m_selectedImageColor = red;
				m_selectedTextA_Color = redA;
				m_selectedTextB_Color = redB;
				m_selectedTextC_Color = redC;
				break;	
			case "green":
				m_selectedImageColor = green;
				m_selectedTextA_Color = greenA;
				m_selectedTextB_Color = greenB;
				m_selectedTextC_Color = greenC;
				break;	
			case "yellow":
				m_selectedImageColor = yellow;
				m_selectedTextA_Color = yellowA;
				m_selectedTextB_Color = yellowB;
				m_selectedTextC_Color = yellowC;
				break;	
		}
		SetUI();
	}	

	public void SetUI()
	{
		if(colorizeImage != null)
		{
			//update the color of images 
			colorizeImage.color = m_selectedImageColor;
		}
		if(colorizeTextA != null)
		{
			//update the color of given texts
			colorizeTextA.color = m_selectedTextA_Color;
		}
		if(colorizeTextB != null)
		{
			//update the color of given texts
			colorizeTextB.color = m_selectedTextB_Color;
		}
		if(colorizeTextC != null)
		{
			//update the color of given texts
			colorizeTextC.color = m_selectedTextC_Color;
		}
	}
}
