using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{
	float spaceBetweenLines = 0.2f; // Pixlar i varje koordinat. 0.0 �r 0 och 1 �r 23x23 XY
	ParabolicCurve curve, curve2, curve3;

	void Start() // main
	{
		// Setup f�r hela programmet - storlek p� sk�rm - pensel- tjocklek
		Stroke(128); // F�rg p� penseldrag
		StrokeWeight(0.2f); // Float - tjocklek p� pennan
		curve = new ParabolicCurve(10);
		curve2 = new ParabolicCurve(20, 2);
		curve3 = new ParabolicCurve(5, 5);
	}
	// Ritar ut grafiken - k�r den h�r koden - ritar bakgrund varje frame & kurvor varje frame
	void Update()
	{
		Background(255, 255, 255); // Bakgrund RGB
		curve.DrawCurve(); // K�r denna i draw varje frame
		curve2.DrawCurve(); // K�r denna i draw varje frame
		curve3.DrawCurve(); // K�r denna i draw varje frame
	}

	void DrawCurve()
	{
		for (int i = 0; i < Height/spaceBetweenLines; i++)
		{
			if (i % 3 == 0)
				Stroke(0);
			else
				Stroke(128);

			float x1 = i * spaceBetweenLines;
			float y2 = Height - i * spaceBetweenLines;
			Line(x1, 0 , 0, y2 );
		}
	}
}

public class ParabolicCurve : ProcessingLite.GP21
{
	int lines;
	float spaceBetweenLines;
	float offset;
	
	public ParabolicCurve(int numberOfLines, float offset = 0)
	{
		lines = numberOfLines;
		spaceBetweenLines = Height / lines;
		this.offset = offset;
	}

	public void DrawCurve()
	{
		for (int i = 0; i < lines; i++)
		{
			if (i % 3 == 0)
				Stroke(0);
			else
				Stroke(128);

			float x1 = i * spaceBetweenLines;
			float y2 = Height - i * spaceBetweenLines;
			Line(x1+offset, 0 + offset, 0 + offset, y2 + offset);
		}
	}
}
