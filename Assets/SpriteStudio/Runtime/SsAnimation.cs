/**
	SpriteStudio
	
	An animation asset
	
	Copyright(C) 2003-2012 Web Technology Corp. 
	All rights reserved
*/

//#define _BUILD_UNIFIED_SHADERS

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public enum UseUnifiedShaderEnum
{
	Default,	///< use global setting in database
	Yes,
	No,
}

[System.Serializable]
public class SsAnimation : ScriptableObject
{
	static public bool operator true(SsAnimation p){return p != null;}
	static public bool operator false(SsAnimation p){return p == null;}
	
	public	string			OriginalPath;	///< original animation resource path
	
#if _BUILD_UNIFIED_SHADERS
	public	UseUnifiedShaderEnum	_UseUnifiedShader;
	[HideInInspector] public	bool	UseUnifiedShader;	///< Not supported for OpenGL ES 1.1
#endif

	[HideInInspector] public bool	UseScaleFactor = false;
	[HideInInspector] public float	ScaleFactor = 1f;

	public	int				FPS;
	public	int				EndFrame;
	public	bool			hvFlipForImageOnly;
	public	SsImageFile[]	ImageList;
	public	SsPartRes[]		PartList;

	[HideInInspector] public int ImportedTime;
	[HideInInspector] public int ImportedTimeHigh;
	
	public void
	UpdateImportedTime()
	{
		long now = System.DateTime.Now.ToBinary();
		ImportedTime = (int)now;
		ImportedTimeHigh = (int)(now >> 32);
	}
	
	public bool
	EqualsImportedTime(int importedTime, int importedTimeHigh)
	{
		return ImportedTime == importedTime && ImportedTimeHigh == importedTimeHigh;
	}
}
