import { createTheme } from '@mui/material/styles'

const theme = createTheme({
  palette: {
    primary: {
      light: '#AED6D450',
      main: '#AED6D4',
      // dark: will be calculated from palette.primary.main,
      contrastText: '#FFF',
    },
    secondary: {
      light: '#ffcc00',
      main: '#FFB01E',
      // dark: will be calculated from palette.secondary.main,
      contrastText: '#FFF',
    },
    // Provide every color token (light, main, dark, and contrastText) when using
    // custom colors for props in Material UI's components.
    // Then you will be able to use it like this: `<Button color="custom">`
    // (For TypeScript, you need to add module augmentation for the `custom` value)
    custom: {
      light: '#4F5753',
      main: '#343d3a',
      dark: '#2D3635',
      contrastText: '#FFF',
    },
    // Used by `getContrastText()` to maximize the contrast between
    // the background and the text.
    //contrastThreshold: 3,
    // Used by the functions below to shift a color's luminance by approximately
    // two indexes within its tonal palette.
    // E.g., shift from Red 500 to Red 300 or Red 700.
    //tonalOffset: 0.2,
  },
  components: {
    MuiFormControl: {
      defaultProps: {
        // The props to change the default for.
        //disableRipple: true, // No more ripple, on the whole application 💣!
        //height: '10px!important',
        //marginRight: '10px',
        //mr: 50,
        //width: '500px',
      },
    },
    MuiButtonBase: {
      // defaultProps: {
      //   textTransform: 'none',
      //   //disableRipple: true,
      // },
    },
    MuiLink: {
      variants: [
        {
          props: { variant: 'dark' },
          style: {
            color: '#343d3a',
            '&:hover': {
              color: '#2D3635',
            },
          },
        },
      ],
    },
  },
})
export default theme
