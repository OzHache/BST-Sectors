using UnityEngine;
public class Sector
{
    private Vector3 m_center;
    //subsectors
    private SubSector a = new SubSector();    //-x, +y, +z
    private SubSector b = new SubSector();    //+x, +y, +z
    private SubSector c = new SubSector();    //-x, +y, -z
    private SubSector d = new SubSector();    //+x, +y, -z
    private SubSector e = new SubSector();    //-x, -y, +z
    private SubSector f = new SubSector();    //+x, -y, +z
    private SubSector g = new SubSector();    //-x, -y, -z
    private SubSector h = new SubSector();    //+x, -y, -z


    public Add(Vector3 point){
        var subSector = GetSubSector(point);
        subSector.Add(point);
    }
    public FindClosestPoint(Vector3 point){
        var subSector = GetSubSector(point);
        return subSector.FindClosestPoint(point);
    }
    public bool Remove(Vector3 point){
        var subSector = GetSubSector(point);
        return subSector.Remove(point);
    }
    public bool Contains(Vector3 point){
        var subSector = GetSubSector(point);
        return subSector.Contains(point);
    }
    
    public int Count(){
        int count = 0;
        count += a.Count();
        count += b.Count();
        count += c.Count();
        count += d.Count();
        count += e.Count();
        count += f.Count();
        count += g.Count();
        count += h.Count();
        return count;
    }
    public void Clear(){
        a.Clear();
        b.Clear();
        c.Clear();
        d.Clear();
        e.Clear();
        f.Clear();
        g.Clear();
        h.Clear();
    }

    private Vector3 GetSubSector(Vector3 point){
        byte posX = (byte)2;
        byte posY = (byte)4;
        byte posZ = (byte)8;
        byte sorter = (byte)0;
        //default to - is inclusive
        if(point.x > m_center.x){
            sorter += posX;
        }
        if(point.y > m_center.y){
            sorter += posY;
        }
        if(point.z > m_center.z){
            sorter += posZ;
        }
        switch ((Int)sorter){
            case 0:     //-x, -y, -z
                return g;
            case 2:     //+x, -y, -z
                return h;
            case 4:     //-x, +y, -z
                return c;
            case 6:     //+x, +y, -z
                return d;
            case 8:     //-x, -y, +z
                return e;
            case 10:    //+x, -y, +z
                return f;
            case 12:    //-x, +y, +z
                return a;
            case 14:    //+x, +y, +z
                return b;
            case default:
                return g;
        }
    }
}
public class SubSector{
    public SubSector points = new SubSector();
    public Vector3 center = vector3.zero;
    public void Add(Vector3 point){
        points.Add(point);
        CalculateCenter();
        SortByDistance();
    }
    public Vector3 FindClosestPoint(Vector3 point){
        float minDistance = float.MaxValue;
        Vector3 closestPoint = Vector3.zero;
        foreach(Vector3 p in points){
            float distance = Vector3.Distance(p, point);
            if(distance < minDistance){
                minDistance = distance;
                closestPoint = p;
            }
        }
        return closestPoint;
    }
    public Bool Remove(Vector3 point){
        return points.Remove(point);
        CalculateCenter();
        SortByDistance();
    }
    public Bool Contains(Vector3 point){
        return points.Contains(point);
    }
    public int Count(){
        return points.Count();
    }
    public void Clear(){
        points.Clear();
    }
    private Vector3 CalculateCenter(){
        Vector3 center = Vector3.zero;
        foreach(Vector3 p in points){
            center += p;
        }
        center /= points.Count();
        return center;
    }
    private void SortByDistance(){
        float[] distances = new float[points.Count()];
        for(int i = 0; i < points.Count(); i++){
            distances[i] = Vector3.Distance(points[i], center);
        }
        Vector3[] sortedPoints = new Vector3[points.Count()];
        for(int i = 0; i < points.Count(); i++){
            int index = 0;
            float minDistance = float.MaxValue;
            for(int j = 0; j < points.Count(); j++){
                if(distances[j] < minDistance){
                    minDistance = distances[j];
                    index = j;
                }
            }
            sortedPoints[i] = points[index];
            distances[index] = float.MaxValue;
        }
    }
}