using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(DijkstraDisplay))]
public class DiykstraMethod : MonoBehaviour
{
    //[SerializeField] private GameObject _from;
    //[SerializeField] private GameObject _to;
    private DijkstraDisplay _display;
    private int MAX;
    private Dictionary<int, Vertex> _parents;
    private Dictionary<int, double> _distance;
    
    private void Start() 
    {
        _display = GetComponent<DijkstraDisplay>();
    }
    public double startDijkstra(Vertex from, Vertex to) 
    {
        //findDaWay(DataBase.vertices[0], DataBase.vertices[DataBase.GetAmountOfVertex()-1]);
        return findDaWay(from, to);
    }
    private double findDaWay(Vertex start, Vertex end)
    {
        int MAX = DataBase.GetAmountOfVertex();
        List<Vertex> S = new List<Vertex>(DataBase.vertices);
        //Dictionary<char, double> D = new Dictionary<char, double>(vertexes.Count);
        _distance = new Dictionary<int, double>(MAX);
        /*Dictionary<char, int> sortedD = (from entry in D
                      orderby entry.Value
                      ascending
                      select entry);*/
        _parents = new Dictionary<int, Vertex>(MAX);
        S.Remove(start);
        _distance[start.GetId()] = 0;

        //for (int i = 0; i < MAX; i++)
        foreach (Vertex vertex in S)
        {
            if (start == vertex)
                continue;

            Edge[] goodEdges = start.GetEdges().Where(x => x.GetId() == vertex.GetId()).ToArray();
            if (goodEdges.Length != 0)
            {
                _distance[vertex.GetId()] = goodEdges[0].GetValue();
                _parents[vertex.GetId()] = start;
            }
            else
            {
                _distance[vertex.GetId()] = 99999999;
                _parents[vertex.GetId()] = null;
            }
            /*if (start.GetId() == i)
                continue;

            Edge[] goodEdges = start.GetEdges().Where(x => x.GetId() == DataBase.vertices[i].GetId()).ToArray();
            if (goodEdges.Length != 0)
            {
                D[i] = goodEdges[0].GetValue();
                Parent[i] = start;
            }
            else
            {
                D[i] = 99999999;
                Parent[i] = null;
            }
            */
        }



        while (S.Count != 0)
        {
            Vertex choosen = null;
            double min = 999999;
            foreach (var el in S)
            {
                if (_distance[el.GetId()] < min)
                {
                    min = _distance[el.GetId()];
                    choosen = el;
                }
            }

            S.Remove(choosen);

            foreach (var el in S)
            {
                double value = choosen.GetEdges().Where(x => x.GetId() == el.GetId()).DefaultIfEmpty(new Edge()).Min().GetValue();
                if (value == 0)
                    continue;
                if (_distance[el.GetId()] > _distance[choosen.GetId()] + value)
                {
                    _distance[el.GetId()] = _distance[choosen.GetId()] + value;
                    _parents[el.GetId()] = choosen;
                }
            }


        }
        //Debug.Log("Result = " + _distance[end.GetId()]);
        FindWay(start, end);
        return _distance[end.GetId()];

    }
    private void FindWay(Vertex start, Vertex end) 
    {
        List<Edge> way = new List<Edge>();
        Vertex currVertex = end;
        //way.Add(currVertex);
        Edge currEdge = null;
        while (currVertex != start)
        {
            //currEdge = currVertex.GetInputEdges().Where(edge => edge.GetId() == _parents[currVertex.GetId()].GetId()).First();
            currEdge = _parents[currVertex.GetId()].GetEdges().Where(edge => edge.GetId() == currVertex.GetId()).First();
            currVertex =_parents[currVertex.GetId()];
            way.Add(currEdge);
        }
        way.Reverse();

        _display.DisplayWay(way);
    }
   
}
