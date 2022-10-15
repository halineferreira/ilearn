import React, { Component } from 'react'
import { Divider } from '@mui/material'
import Link from '@mui/material/Link'
import './style.css'

const styleLinks = {
  textAlign: 'left',
  listStyleType: 'none',
}

export class Footer extends Component {
  render() {
    return (
      <footer>
        <ul style={styleLinks}>
          <li>
            <Link variant="dark">Quem somos</Link>
          </li>
          <li>
            <Link variant="dark">Política de Privacidade</Link>
          </li>
          <li>
            <Link variant="dark">Contato</Link>
          </li>
        </ul>
        <Divider />
        <p>
          © Copyright 2022 - iLearn - aulas particulares - Todos os direitos
          reservados
        </p>
      </footer>
    )
  }
}
