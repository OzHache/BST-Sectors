
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
        subSector.Add(point) //obviously you cannot add to an array in C# so you can use a list
                            // then make an array of that list's size, this would even give you the
                            //opportunity to sort by distance. 
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
//use Unity instead
struct Vector3{
    float x, y, z;
}
