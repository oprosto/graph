using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

class AdjEdge 
{
    public AdjEdge(int _to, double _value) 
    {
        to = _to;
        value = _value;
    }
    public AdjEdge()
    {
        to = -1;
        value = -1;
    }
    public int to { get; set; }
    public double value { get; set; }
}
class AVertex 
{
    public int id;
    public List<AdjEdge> adjEdges = new List<AdjEdge>();
}

public class DiykstraWay : MonoBehaviour
{
    //Dictionary<char, AVertex> vertexes = new Dictionary<char, AVertex>();
    private static int MAX = 6;
    AVertex[] baseVertexes = new AVertex[MAX];
    
                                               
    private void init() 
    {
        for (int i = 0; i < baseVertexes.Length; i++)
            baseVertexes[i] = new AVertex();
        baseVertexes[0].id = 0;
        baseVertexes[1].id = 1;
        baseVertexes[2].id = 2;
        baseVertexes[3].id = 3;
        baseVertexes[4].id = 4;
        baseVertexes[5].id = 5;
        
        AdjEdge ab = new AdjEdge(1, 25);
        AdjEdge ac = new AdjEdge(2, 5);
        AdjEdge ad = new AdjEdge(3, 30);
        AdjEdge af = new AdjEdge(5, 75);
        baseVertexes[0].adjEdges.Add(ab);
        baseVertexes[0].adjEdges.Add(ac);
        baseVertexes[0].adjEdges.Add(ad);
        baseVertexes[0].adjEdges.Add(af);

        AdjEdge ba = new AdjEdge(0, 12);
        AdjEdge be = new AdjEdge(4, 120);
        AdjEdge bf = new AdjEdge(5, 20);
        baseVertexes[1].adjEdges.Add(ba);
        baseVertexes[1].adjEdges.Add(be);
        baseVertexes[1].adjEdges.Add(bf);

        AdjEdge cb = new AdjEdge(1, 15);
        AdjEdge cd = new AdjEdge(3, 20);
        AdjEdge ce = new AdjEdge(4, 45);
        AdjEdge cf = new AdjEdge(5, 60);
        baseVertexes[2].adjEdges.Add(cb);
        baseVertexes[2].adjEdges.Add(cd);
        baseVertexes[2].adjEdges.Add(ce);
        baseVertexes[2].adjEdges.Add(cf);

        AdjEdge de = new AdjEdge(4, 23);
        AdjEdge df = new AdjEdge(5, 20);
        baseVertexes[3].adjEdges.Add(de);
        baseVertexes[3].adjEdges.Add(df);

        AdjEdge ec = new AdjEdge(2, 75);
        AdjEdge ed = new AdjEdge(3, 20);
        AdjEdge ef = new AdjEdge(5, 20);
        baseVertexes[4].adjEdges.Add(ec);
        baseVertexes[4].adjEdges.Add(ed);
        baseVertexes[4].adjEdges.Add(ef);

        AdjEdge fa = new AdjEdge(0, 40);
        AdjEdge fb = new AdjEdge(1, 15);
        AdjEdge fc = new AdjEdge(2, 15);
        AdjEdge fd = new AdjEdge(3, 26);
        baseVertexes[5].adjEdges.Add(fa);
        baseVertexes[5].adjEdges.Add(fb);
        baseVertexes[5].adjEdges.Add(fc);
        baseVertexes[5].adjEdges.Add(fd);
        
    }
    private void OnEnable () 
    {
        init();
        findDaWay(baseVertexes[0], baseVertexes[5]);
    }
    public void CallDijk() 
    {
        findDaWay(baseVertexes[0], baseVertexes[5]);
    }
    private void findDaWay(AVertex start, AVertex end) 
    {
        List<AVertex> S = new List<AVertex>(baseVertexes);
        //Dictionary<char, double> D = new Dictionary<char, double>(vertexes.Count);
        double[] D = new double[6];
        /*Dictionary<char, int> sortedD = (from entry in D
                      orderby entry.Value
                      ascending
                      select entry);*/
        AVertex[] Parent = new AVertex[MAX];
        S.Remove(start);
        D[start.id] = 0;

        for (int i = 0; i < MAX; i++)
        {
            if (start.id == i)
                continue;

            AdjEdge[] goodEdges = start.adjEdges.Where(x => x.to == baseVertexes[i].id).ToArray();
            if (goodEdges.Length != 0)
            {
                D[i] = goodEdges[0].value;
                Parent[i] = start;
            }
            else
            {
                D[i] = 99999999;
                Parent[i] = null;
            }
            
        }
        
            
        
        while(S.Count != 0) 
        {
            AVertex choosen = null;
            double min = 999999;
            foreach (var el in S)
            {
                if (D[el.id] < min)
                {
                    min = D[el.id];
                    choosen = el;
                }
            }
            
            S.Remove(choosen);

            foreach (var el in S) 
            {
                double value = choosen.adjEdges.Where(x => x.to == el.id).DefaultIfEmpty(new AdjEdge()).Min().value;
                if (value == -1)
                    continue;
                if (D[el.id] > D[choosen.id] + value) 
                {
                    D[el.id] = D[choosen.id] + value;
                    Parent[el.id] = choosen;
                }
            }


        }


    }


    /*
    AVertex findMin(List<AVertex> S) 
    {
        char resKey = ' ';
        int min = 999999;
        foreach (var el in S)
        {
            if ( < min)
            {
                min = D[el];
                resKey = el;
            }
        }
        return vertexes[resKey];
    }*/
}
