public class SectorBST
{
    Vector3 m_center;
    //subsectors
    Vector3[] a;    //-x, +y, +z
    Vector3[] b;    //+x, +y, +z
    Vector3[] c;    //-x, +y, -z
    Vector3[] d;    //+x, +y, -z
    Vector3[] e;    //-x, -y, +z
    Vector3[] f;    //+x, -y, +z
    Vector3[] g;    //-x, -y, -z
    Vector3[] h;    //+x, -y, -z


    Add(Vector3 point){
        var subSector = GetSubSector(point);
        subSector.Add(point)
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
        switch (sorter){
            case 0:     //-x, -y, -z
                return g;
                break;
            case 2:     //+x, -y, -z
                return h;
                break;
            case 4:     //-x, +y, -z
                return c;
                break;
            case 6:     //+x, +y, -z
                return d;
                break;
            case 8:     //-x, -y, +z
                return e;
                break;
            case 10:    //+x, -y, +z
                return f;
                break;
            case 12:    //-x, +y, +z
                return a;
                break;
            case 14:    //+x, +y, +z
                return b;
                break;
        }
    }


}
struct Vector3{
    float x, y, z;
}
