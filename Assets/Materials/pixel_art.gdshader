shader_type canvas_item;
render_mode unshaded;

const vec2 target_resolution = vec2(1280.0/2.5, 720.0/2.5);
const float colors_per_chanel = 8.0;

uniform sampler2D screen_texture : hint_screen_texture, filter_nearest;

void fragment() {
    vec2 uv = floor(SCREEN_UV * target_resolution) / target_resolution; 
    vec3 color = texture(screen_texture, uv).rgb;
    vec3 quantized_color = floor(color * colors_per_chanel) / colors_per_chanel; 
    COLOR = vec4(quantized_color, 1.0);
}
