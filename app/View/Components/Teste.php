<?php

namespace App\View\Components;

use Closure;
use Illuminate\Contracts\View\View;
use Illuminate\View\Component;

class Teste extends Component
{


    public function __construct(
        public string $titulo,
        public string $quantidade = "",
    ){

    }

    public function render(): View|Closure|string
    {
        return view('components.teste'); // nome da view em minúsculo
    }
}
