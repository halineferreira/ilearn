import React, { Component } from 'react'
import { Container } from 'reactstrap'
import { Header } from './Header'
import { Footer } from './Footer'
import { SliderI } from './Slider'

export class Layout extends Component {
  static displayName = Layout.name

  render() {
    return (
      <div>
        <Header />
        <SliderI />
        <Container>{this.props.children}</Container>
        <Footer />
      </div>
    )
  }
}
