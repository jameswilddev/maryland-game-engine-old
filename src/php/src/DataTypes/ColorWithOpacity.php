<?php

namespace MarylandGameEngine\DataTypes;

use InvalidArgumentException;

/**
 * A 32-bit red/green/blue/opacity color.
 */
class ColorWithOpacity
{
  private $red;
  private $green;
  private $blue;
  private $opacity;

  /**
   * Creates a new 32-bit red/green/blue/opacity color.
   * @param int $red The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @param int $green The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @param int $blue The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @param int $opacity The opacity of the color, where 0 is fully transparent and 255 is fully opaque.
   * @throws InvalidArgumentException Thrown when red is not an integer.
   * @throws InvalidArgumentException Thrown when red is less than 0.
   * @throws InvalidArgumentException Thrown when red is greater than 255.
   * @throws InvalidArgumentException Thrown when green is not an integer.
   * @throws InvalidArgumentException Thrown when green is less than 0.
   * @throws InvalidArgumentException Thrown when green is greater than 255.
   * @throws InvalidArgumentException Thrown when blue is not an integer.
   * @throws InvalidArgumentException Thrown when blue is less than 0.
   * @throws InvalidArgumentException Thrown when blue is greater than 255.
   * @throws InvalidArgumentException Thrown when opacity is not an integer.
   * @throws InvalidArgumentException Thrown when opacity is less than 0.
   * @throws InvalidArgumentException Thrown when opacity is greater than 255.
   */
  function __construct($red, $green, $blue, $opacity)
  {
    if (!is_int($red)) {
      throw new InvalidArgumentException("Red is not an integer.");
    } else if ($red < 0) {
      throw new InvalidArgumentException("Red is less than 0.");
    } else if ($red > 255) {
      throw new InvalidArgumentException("Red is greater than 255.");
    } else if (!is_int($green)) {
      throw new InvalidArgumentException("Green is not an integer.");
    } else if ($green < 0) {
      throw new InvalidArgumentException("Green is less than 0.");
    } else if ($green > 255) {
      throw new InvalidArgumentException("Green is greater than 255.");
    } else if (!is_int($blue)) {
      throw new InvalidArgumentException("Blue is not an integer.");
    } else if ($blue < 0) {
      throw new InvalidArgumentException("Blue is less than 0.");
    } else if ($blue > 255) {
      throw new InvalidArgumentException("Blue is greater than 255.");
    } else  if (!is_int($opacity)) {
      throw new InvalidArgumentException("Opacity is not an integer.");
    } else if ($opacity < 0) {
      throw new InvalidArgumentException("Opacity is less than 0.");
    } else if ($opacity > 255) {
      throw new InvalidArgumentException("Opacity is greater than 255.");
    } else {
      $this->red = $red;
      $this->green = $green;
      $this->blue = $blue;
      $this->opacity = $opacity;
    }
  }

  /**
   * Retrieves the intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @return int The intensity of the red channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   */
  public function getRed()
  {
    return $this->red;
  }

  /**
   * Retrieves the intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @return int The intensity of the green channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   */
  public function getGreen()
  {
    return $this->green;
  }

  /**
   * Retrieves the intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   * @return int The intensity of the blue channel, where 0 is the minimum possible intensity and 255 is the maximum possible intensity, premultiplied by the opacity.
   */
  public function getBlue()
  {
    return $this->blue;
  }

  /**
   * Retrieves the opacity of the color, where 0 is fully transparent and 255 is fully opaque.
   * @return int The opacity of the color, where 0 is fully transparent and 255 is fully opaque.
   */
  public function getOpacity()
  {
    return $this->opacity;
  }

  /**
   * Retrieves a sequence of bytes which describe this color.
   * @return string A sequence of bytes which describe this color.
   */
  public function getSerialized()
  {
    return pack("C*", $this->red, $this->green, $this->blue, $this->opacity);
  }
}
