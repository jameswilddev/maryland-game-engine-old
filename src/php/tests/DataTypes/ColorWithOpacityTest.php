<?php

namespace MarylandGameEngine\Tests\DataTypes;

use InvalidArgumentException;
use MarylandGameEngine\DataTypes\ColorWithOpacity;
use MarylandGameEngine\Tests\Generate;
use PHPUnit\Framework\TestCase;

final class ColorWithOpacityTest extends TestCase
{
  public function test_exposes_given_data()
  {
    $red = 0x3f;
    $green = 0x03;
    $blue = 0xa1;
    $opacity = 0x48;

    $colorWithOpacity = new ColorWithOpacity($red, $green, $blue, $opacity);

    $this->assertEquals($red, $colorWithOpacity->getRed());
    $this->assertEquals($green, $colorWithOpacity->getGreen());
    $this->assertEquals($blue, $colorWithOpacity->getBlue());
    $this->assertEquals($opacity, $colorWithOpacity->getOpacity());
    $this->assertEquals("\x3f\x03\xa1\x48", $colorWithOpacity->getSerialized());
  }

  public function test_allows_minimum()
  {
    new ColorWithOpacity(0, 0, 0, 0);

    $this->expectNotToPerformAssertions();
  }

  public function test_allows_maximum()
  {
    new ColorWithOpacity(255, 255, 255, 255);

    $this->expectNotToPerformAssertions();
  }

  public function test_throws_exception_when_red_non_integer()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Red is not an integer.");

    $red = 3.1;
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_red_minus_one()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Red is less than 0.");

    $red = -1;
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_red_minus_two()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Red is less than 0.");

    $red = -2;
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_red_256()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Red is greater than 255.");

    $red = 256;
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_red_257()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Red is greater than 255.");

    $red = 257;
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_green_non_integer()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Green is not an integer.");

    $red = Generate::byte();
    $green = 3.1;
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_green_minus_one()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Green is less than 0.");

    $red = Generate::byte();
    $green = -1;
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_green_minus_two()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Green is less than 0.");

    $red = Generate::byte();
    $green = -2;
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_green_256()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Green is greater than 255.");

    $red = Generate::byte();
    $green = 256;
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_green_257()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Green is greater than 255.");

    $red = Generate::byte();
    $green = 257;
    $blue = Generate::byte();
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_blue_non_integer()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Blue is not an integer.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = 3.1;
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_blue_minus_one()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Blue is less than 0.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = -1;
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_blue_minus_two()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Blue is less than 0.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = -2;
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_blue_256()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Blue is greater than 255.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = 256;
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_blue_257()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Blue is greater than 255.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = 257;
    $opacity = Generate::byte();

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_opacity_non_integer()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Opacity is not an integer.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = 3.1;

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_opacity_minus_one()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Opacity is less than 0.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = -1;

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_opacity_minus_two()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Opacity is less than 0.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = -2;

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_opacity_256()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Opacity is greater than 255.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = 256;

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_throws_exception_when_opacity_257()
  {
    $this->expectException(InvalidArgumentException::class);
    $this->expectExceptionMessage("Opacity is greater than 255.");

    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = 257;

    new ColorWithOpacity($red, $green, $blue, $opacity);
  }

  public function test_equal()
  {
    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    $a = new ColorWithOpacity($red, $green, $blue, $opacity);
    $b = new ColorWithOpacity($red, $green, $blue, $opacity);

    $this->assertEquals($a, $b);
  }

  public function test_inequal_red()
  {
    $green = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    $a = new ColorWithOpacity(Generate::byte(), $green, $blue, $opacity);
    $b = new ColorWithOpacity(Generate::byte(), $green, $blue, $opacity);

    $this->assertNotEquals($a, $b);
  }

  public function test_inequal_green()
  {
    $red = Generate::byte();
    $blue = Generate::byte();
    $opacity = Generate::byte();

    $a = new ColorWithOpacity($red, Generate::byte(), $blue, $opacity);
    $b = new ColorWithOpacity($red, Generate::byte(), $blue, $opacity);

    $this->assertNotEquals($a, $b);
  }

  public function test_inequal_blue()
  {
    $red = Generate::byte();
    $green = Generate::byte();
    $opacity = Generate::byte();

    $a = new ColorWithOpacity($red, $green, Generate::byte(), $opacity);
    $b = new ColorWithOpacity($red, $green, Generate::byte(), $opacity);

    $this->assertNotEquals($a, $b);
  }

  public function test_inequal_opacity()
  {
    $red = Generate::byte();
    $green = Generate::byte();
    $blue = Generate::byte();

    $a = new ColorWithOpacity($red, $green, $blue, Generate::byte());
    $b = new ColorWithOpacity($red, $green, $blue, Generate::byte());

    $this->assertNotEquals($a, $b);
  }
}
