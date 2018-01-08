attribute vec3 aVertexPosition;
attribute vec3 aVertexColor;

uniform mat4 uMVMatrix;
uniform mat4 uPMatrix;

varying vec3 vColor;

void main(void)
{

    gl_Position = uPMatrix*uMVMatrix * vec4(aVertexPosition, 1.0);
    vColor = aVertexColor;//*vec4(1.0, 0.5, 0.2, 1.0);//
}
