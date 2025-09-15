{{-- @php
    dump($attributes);
@endphp --}}
<div style="width: 400px; height: 200px; background-color: rgb(157, 255, 0); margin-bottom: 20px;">
    <h1>Titulo: {{ $titulo }}</h1>
    <p>{{ $quantidade }}</p>
    <div
        style="width: 200px; height: 30px; background-color: rgb(129, 127, 255);
        display: flex; align-items: center; justify-content: center;">
        {{ $icon }}
        <a href="#" style="color:white;">Acessar</a>
    </div>
</div>
