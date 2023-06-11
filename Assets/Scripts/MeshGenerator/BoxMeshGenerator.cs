using System.Collections;
using UnityEngine;

public class BoxMeshGenerator : BulletMeshGenerator
{
    [SerializeField] private float size = 1f;
    [SerializeField] private float deformationStrength = 0.1f;

    public override IEnumerator GenerateMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[8];
        int[] triangles = new int[36];

        vertices[0] = new Vector3(-size, size, -size);
        vertices[1] = new Vector3(size, size, -size);
        vertices[2] = new Vector3(size, -size, -size);
        vertices[3] = new Vector3(-size, -size, -size);
        vertices[4] = new Vector3(-size, size, size);
        vertices[5] = new Vector3(size, size, size);
        vertices[6] = new Vector3(size, -size, size);
        vertices[7] = new Vector3(-size, -size, size);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += RandomDeformation();
            yield return null;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 5;
        triangles[7] = 4;
        triangles[8] = 7;
        triangles[9] = 5;
        triangles[10] = 7;
        triangles[11] = 6;

        triangles[12] = 4;
        triangles[13] = 0;
        triangles[14] = 3;
        triangles[15] = 4;
        triangles[16] = 3;
        triangles[17] = 7;

        triangles[18] = 1;
        triangles[19] = 5;
        triangles[20] = 6;
        triangles[21] = 1;
        triangles[22] = 6;
        triangles[23] = 2;

        triangles[24] = 4;
        triangles[25] = 5;
        triangles[26] = 1;
        triangles[27] = 4;
        triangles[28] = 1;
        triangles[29] = 0;

        triangles[30] = 3;
        triangles[31] = 2;
        triangles[32] = 6;
        triangles[33] = 3;
        triangles[34] = 6;
        triangles[35] = 7;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    public IEnumerator GenerateMesh2()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        Vector3[] vertices = new Vector3[8];
        int[] triangles = new int[36];

        vertices[0] = new Vector3(-size, size, -size);
        vertices[1] = new Vector3(size, size, -size);
        vertices[2] = new Vector3(size, -size, -size);
        vertices[3] = new Vector3(-size, -size, -size);
        vertices[4] = new Vector3(-size, size, size);
        vertices[5] = new Vector3(size, size, size);
        vertices[6] = new Vector3(size, -size, size);
        vertices[7] = new Vector3(-size, -size, size);

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] += RandomDeformation();
            yield return null; // Затримка між кроками генерації меша
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;
        triangles[3] = 0;
        triangles[4] = 2;
        triangles[5] = 3;

        triangles[6] = 5;
        triangles[7] = 4;
        triangles[8] = 7;
        triangles[9] = 5;
        triangles[10] = 7;
        triangles[11] = 6;

        triangles[12] = 4;
        triangles[13] = 0;
        triangles[14] = 3;
        triangles[15] = 4;
        triangles[16] = 3;
        triangles[17] = 7;

        triangles[18] = 1;
        triangles[19] = 5;
        triangles[20] = 6;
        triangles[21] = 1;
        triangles[22] = 6;
        triangles[23] = 2;

        triangles[24] = 4;
        triangles[25] = 5;
        triangles[26] = 1;
        triangles[27] = 4;
        triangles[28] = 1;
        triangles[29] = 0;

        triangles[30] = 3;
        triangles[31] = 2;
        triangles[32] = 6;
        triangles[33] = 3;
        triangles[34] = 6;
        triangles[35] = 7;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }

    private Vector3 RandomDeformation()
    {
        return new Vector3(
            Random.Range(-deformationStrength, deformationStrength),
            Random.Range(-deformationStrength, deformationStrength),
            Random.Range(-deformationStrength, deformationStrength)
        );
    }
}