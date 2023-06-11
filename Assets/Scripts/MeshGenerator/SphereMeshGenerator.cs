using System.Collections;
using UnityEngine;

public class SphereMeshGenerator : BulletMeshGenerator
{
    [SerializeField] private float radius = 1f;
    [SerializeField] private int latitudeSegments = 10;
    [SerializeField] private int longitudeSegments = 10;

    public override IEnumerator GenerateMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        meshFilter.mesh = mesh;

        int vertexCount = (latitudeSegments + 1) * (longitudeSegments + 1);
        Vector3[] vertices = new Vector3[vertexCount];
        Vector2[] uv = new Vector2[vertexCount];
        int[] triangles = new int[latitudeSegments * longitudeSegments * 6];

        int index = 0;

        for (int lat = 0; lat <= latitudeSegments; lat++)
        {
            float normalizedLatitude = Mathf.PI * lat / latitudeSegments;
            float sinNormalizedLatitude = Mathf.Sin(normalizedLatitude);
            float cosNormalizedLatitude = Mathf.Cos(normalizedLatitude);

            for (int lon = 0; lon <= longitudeSegments; lon++)
            {
                float normalizedLongitude = 2f * Mathf.PI * lon / longitudeSegments;
                float sinNormalizedLongitude = Mathf.Sin(normalizedLongitude);
                float cosNormalizedLongitude = Mathf.Cos(normalizedLongitude);

                float x = radius * sinNormalizedLatitude * cosNormalizedLongitude;
                float y = radius * cosNormalizedLatitude;
                float z = radius * sinNormalizedLatitude * sinNormalizedLongitude;

                vertices[index] = new Vector3(x, y, z);
                uv[index] = new Vector2((float)lon / longitudeSegments, (float)lat / latitudeSegments);
                index++;
            }
        }

        index = 0;

        for (int lat = 0; lat < latitudeSegments; lat++)
        {
            for (int lon = 0; lon < longitudeSegments; lon++)
            {
                int current = lat * (longitudeSegments + 1) + lon;
                int next = current + longitudeSegments + 1;

                triangles[index++] = current;
                triangles[index++] = next + 1;
                triangles[index++] = current + 1;

                triangles[index++] = current;
                triangles[index++] = next;
                triangles[index++] = next + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        yield return null;
    }
}