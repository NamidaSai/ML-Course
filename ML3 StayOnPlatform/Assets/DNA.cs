using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValues = 0;

    public DNA(int length, int value)
    {
        dnaLength = length;
        maxValues = value;
        SetRandom();
    }

    public void SetRandom()
    {
        genes.Clear();
        for (int i = 0; i < dnaLength; i++)
        {
            genes.Add(Random.Range(0, maxValues));
        }
    }

    public void SetInt(int position, int value)
    {
        genes[position] = value;
    }

    public void Combine(DNA dna1, DNA dna2)
    {
        for (int i = 0; i < dnaLength; i++)
        {
            if (i < dnaLength / 2.0f)
            {
                int combination = dna1.genes[i];
                genes[i] = combination;
            }
            else
            {
                int combination = dna2.genes[i];
                genes[i] = combination;
            }
        }
    }

    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }

    public int GetGene(int position)
    {
        return genes[position];
    }
}
