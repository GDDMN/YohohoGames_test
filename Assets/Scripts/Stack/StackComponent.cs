using System;
using System.Collections.Generic;

[Serializable]  
public struct StackComponent
{
  public int Count;
  public List<StackItem> StackItems;
}
